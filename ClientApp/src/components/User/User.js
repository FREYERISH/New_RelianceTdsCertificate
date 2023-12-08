 /*import React from 'react';*/

/*const User = () => {
    return (
        <h1>User</h1>
      
    );
};*/
import React, { useState } from 'react';
import axios from 'axios';
import { Row, Col } from 'react-bootstrap';
import './User.scss';

const User = () => {
    const [financialYear, setFinancialYear] = useState('');
    const [quarter, setQuarter] = useState('');
    const [data, setData] = useState([]);

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await axios.get(`/api/user/data`, {
                params: {
                    financialYear,
                    quarter,
                },
            });

            const { data: responseData } = response;
            setData(responseData);
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="user-data-view">
            <h2>User View</h2>

            <form onSubmit={handleSubmit}>
                <label htmlFor="financialYear">Financial Year:</label>
                <input
                    type="text"
                    id="financialYear"
                    name="financialYear"
                    value={financialYear}
                    onChange={(event) => setFinancialYear(event.target.value)}
                />

                <label htmlFor="quarter">Quarter:</label>
                <input
                    type="text"
                    id="quarter"
                    name="quarter"
                    value={quarter}
                    onChange={(event) => setQuarter(event.target.value)}
                />

                <button type="submit">Submit</button>
            </form>

            {data.length > 0 && (
                <div className="grid-view">
                    <Row>
                        <Col>Document Name</Col>
                        <Col>Current Financial Year & Quarter</Col>
                        <Col>File Size</Col>
                        <Col>Download</Col>
                    </Row>

                    {data.map((item) => (
                        <Row key={item.id}>
                            <Col>{item.documentName}</Col>
                            <Col>{item.financialYear} - {item.quarter}</Col>
                            <Col>{item.fileSize}</Col>
                            <Col>
                                <a href={`/api/user/download/${item.id}`}>Download</a>
                            </Col>
                        </Row>
                    ))}
                </div>
            )}
        </div>
    );
};

export default User;




/*export default User;*/