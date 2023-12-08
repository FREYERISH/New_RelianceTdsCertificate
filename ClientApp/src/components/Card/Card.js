import React, { useState } from 'react';
import './Card.scss';
import Swal from 'sweetalert2';
import axios from 'axios';

const Card = () => {
    const [pan, setPan] = useState('');
    const [otp, setOtp] = useState('');

    const handleGetOtp = async (event) => {
        event.preventDefault();

        if (!pan) {
            Swal.fire('Error!', 'Please enter your PAN number.', 'error');
            return;
        }

        try {
            const response = await axios.post('/api/send-otp-email', {
                pan,
            });

            if (response.status === 404) {
                Swal.fire('Error!', 'The email address could not be found.', 'error');
                return;
            }

            const data = await response.json();

            if (data.success) {
                Swal.fire('Success!', 'OTP sent to your email.', 'success');
                setOtp(''); 
            } else {
                Swal.fire('Error!', data.message, 'error');
            }
        } catch (error) {
            console.error('Error sending OTP:', error);
            Swal.fire('Error!', 'Failed to send OTP. Please try again later.', 'error');
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        if (!pan || !otp) {
            Swal.fire(
                'Error!',
                'Please enter your PAN number and OTP.',
                'error'
            );
            return;
        }

        try {
            const response = await axios.post('/api/verify-otp', {
                pan,
                otp,
            });

            const data = await response.json();

            if (data.token) {
                localStorage.setItem('authToken', data.token); 
                Swal.fire('Success!', 'Login successful!', 'success');
                window.location.href = '/Admin'; 
            } else {
                Swal.fire(
                    'Error!',
                    'Invalid credentials or incorrect OTP. Please try again.',
                    'error'
                );
            }
        } catch (error) {
            console.error('Error during login:', error);
            Swal.fire(
                'Error!',
                'Something went wrong. Please try again later.',
                'error'
            );
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
