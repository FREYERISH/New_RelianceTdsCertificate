/* eslint-disable no-unused-vars */
import React, { useState, useEffect } from 'react';
import './Card.scss';
import Swal from 'sweetalert2';
import axios from 'axios';

const Card = () => {
    const [pan, setPan] = useState('');
    const [otp, setOtp] = useState('');

    useEffect(() => {
        // Clear the OTP field on initial render
        setOtp('');
    }, []);

    const handleGetOtp = async (event) => {
        event.preventDefault();

        const API_URL = "https://localhost:7083/";

        if (!pan) {
            Swal.fire('Error!', 'Please enter your PAN number.', 'error');
            return;
        }

        try {
            const response = await axios.post(this.API_URL+'api/Mail/GenerateOtp', {
                pan,
            });

            if (response.status === 404) {
                Swal.fire('Error!', 'User with provided PAN number not found.', 'error');
                return;
            }

            const data = await response.json();

            if (data.success) {
                Swal.fire('Success!', 'OTP sent to your email.', 'success');
            } else {
                Swal.fire('Error!', data.message, 'error');
            }
        } catch (error) {
            console.error('Error sending OTP:', error);
            if (error.response) {
                // Specific error handling based on response status
                switch (error.response.status) {
                    case 401:
                        Swal.fire('Error!', 'Invalid credentials. Please try again.', 'error');
                        break;
                    case 500:
                        Swal.fire('Error!', 'Something went wrong on the server. Please try again later.', 'error');
                        break;
                    default:
                        Swal.fire('Error!', 'Failed to send OTP. Please try again later.', 'error');
                }
            } else {
                // Network or other non-response errors
                Swal.fire('Error!', 'Failed to connect to server. Please check your internet connection.', 'error');
            }
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        if (!pan || !otp) {
            Swal.fire('Error!', 'Please enter your PAN number and OTP.', 'error');
            return;
        }

        try {
            const response = await axios.post('/api/Mail/VerifyOtp', {
                pan,
                otp,
            });

            const data = await response.json();

            if (data.emp) {
                // Successfully logged in, redirect to Admin page
                localStorage.setItem('authToken', data.emp.panNumber);
                Swal.fire('Success!', 'Login successful!', 'success');
                window.location.href = '/Admin';
            } else if (data.message === 'Invalid OTP!') {
                Swal.fire('Error!', 'Invalid OTP. Please try again.', 'error');
            } else if (data.message === 'Otp Expired! Generate New OTP') {
                Swal.fire('Error!', 'OTP expired. Please generate a new one.', 'error');
            } else {
                Swal.fire('Error!', 'Something went wrong. Please try again later.', 'error');
            }
        } catch (error) {
            console.error('Error during login:', error);
            Swal.fire('Error!', 'Something went wrong. Please try again later.', 'error');
        }
    };


    return (
        <div className="card">
            <div className="card-body">
                <h2 className="text-center">TDS Login</h2>
                <br />
                <form onSubmit={handleSubmit} method="post">
                    <div className="form-group">
                        <input
                            type="pan"
                            className="form-control"
                            id="pan"
                            placeholder="Enter PAN Number"
                            name="pan"
                            value={pan}
                            onChange={(e) => setPan(e.target.value)}
                        />
                        <button
                            type="button"
                            className="btn btn-primary btn-sm get-otp-btn"
                            onClick={handleGetOtp}
                        >
                            Get OTP
                        </button>
                    </div>
                    <br />
                    <div className="form-group">
                        <input
                            type="otp"
                            className="form-control"
                            id="otp"
                            placeholder="Enter OTP"
                            name="otp"
                            value={otp}
                            onChange={(e) => setOtp(e.target.value)}
                        />  
                    </div>
                    <button
                        type="submit"
                        id="button"
                        className="btn btn-primary deep-purple btn-block"
                    >
                        Submit
                    </button>
                    <br />
                    <br />
                    <div className="reset">
                        <a href="/resend-otp" className="resend-otp-link">
                            Resend OTP
                        </a>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Card;
