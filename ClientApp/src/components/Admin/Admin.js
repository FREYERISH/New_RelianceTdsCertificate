import React from "react";
import { Link } from "react-router-dom";
import "./Admin.scss";

const Admin = () => {
    const [isUploadActive, setIsUploadActive] = React.useState(false);
    const [isDownloadActive, setIsDownloadActive] = React.useState(false);

    const handleUploadLinkClick = () => {
        setIsUploadActive(true);
        setTimeout(() => {
            setIsUploadActive(false);
        }, 200); // Reset state after a short delay
    };

    const handleDownloadLinkClick = () => {
        setIsDownloadActive(true);
        setTimeout(() => {
            setIsDownloadActive(false);
        }, 200); // Reset state after a short delay
    };

    return (
        <div className="second-page">
            <h2 className="text-center">Admin</h2>
            <br />
            <nav className="nav a">
                <Link
                    to="/Admin/admin-upload"
                    className={`nav-link ${isUploadActive ? "active" : ""}`}
                    onClick={handleUploadLinkClick}
                >
                    Admin Upload
                </Link>
                <Link
                    to="/Admin/admin-download"
                    className={`nav-link ${isDownloadActive ? "active" : ""}`}
                    onClick={handleDownloadLinkClick}
                >
                    Admin Download
                </Link>
            </nav>
        </div>
    );
};

export default Admin;
