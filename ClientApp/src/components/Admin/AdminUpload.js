import React, { useState } from 'react';
import './AdminUpload.scss';
import Swal from 'sweetalert2';
import axios from 'axios';


const AdminUpload = () => {
    const [file, setFile] = useState(null); // State variable to hold the selected file

    const handleFileChange = (event) => {
        setFile(event.target.files[0]); // Update the file state with the selected file
    };

    const handleUpload = async () => {
        if (!file) {
            Swal.fire('Error!', 'Please select a file to upload.', 'error');
            return;
        }

        // Define chunk size (e.g., 1MB)
        const chunkSize = 1048576;

        // Initialize variables for chunking
        let chunkIndex = 0;
        let totalChunks = Math.ceil(file.size / chunkSize);

        while (chunkIndex < totalChunks) {
            // Calculate start and end indices for the current chunk
            const startIndex = chunkIndex * chunkSize;
            const endIndex = Math.min(startIndex + chunkSize, file.size);

            // Create a file chunk
            const chunk = file.slice(startIndex, endIndex);

            // Send the file chunk to the backend server using an appropriate method (e.g., fetch, Axios)
            try {
                const response = await fetch('/api/upload-chunk', {
                    method: 'POST',
                    body: new FormData({
                        chunkIndex,
                        totalChunks,
                        chunk,
                    }),
                });

                const data = await response.json();

                if (data.success) {
                    console.log('Chunk uploaded successfully:', chunkIndex);
                } else {
                    console.error('Failed to upload chunk:', chunkIndex);
                    Swal.fire('Error!', 'Failed to upload file. Please try again later.', 'error');
                    return;
                }
            } catch (error) {
                console.error('Error uploading chunk:', error);
                Swal.fire('Error!', 'Something went wrong. Please try again later.', 'error');
                return;
            }

            chunkIndex++;
        }

        // If all chunks have been uploaded successfully, send a final request to notify the backend
        try {
            const response = await fetch('/api/upload-complete', {
                method: 'POST',
            });

            const data = await response.json();

            if (data.success) {
                Swal.fire('Success!', 'File uploaded successfully!', 'success');
            } else {
                Swal.fire('Error!', 'Failed to upload file. Please try again later.', 'error');
            }
        } catch (error) {
            console.error('Error notifying upload completion:', error);
            Swal.fire('Error!', 'Something went wrong. Please try again later.', 'error');
        }
    };
    return (
        <div className="upload-docs-card">
            <h2 className="upload-docs-heading">Upload Documents</h2>
            <div className="upload-docs-file-picker">
                <input type="file" name="file" id="file" className="inputfile" onChange={handleFileChange} />
            </div>
            <br />
            <button className="upload-docs-bulk-upload-button">Bulk Upload</button>
            <br />
            <button className="upload-docs-download-report-button">Download Report</button>
            <br />
            <button className="upload-docs-upload-button" onClick={handleUpload}>Upload</button>
        </div>
    );
};

export default AdminUpload;
