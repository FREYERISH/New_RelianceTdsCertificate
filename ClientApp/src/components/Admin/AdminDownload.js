import React from "react";
import "./AdminDownload.scss";

const AdminDownload = () => {
    const [searchText, setSearchText] = React.useState("");

    const handleSearchTextChanged = (event) => {
        setSearchText(event.target.value);
    };

    const handleDownloadButtonClick = () => {
        // Download the CSV file here
    };

    return (
        <div className="download-docs-card">
            <h2 className="download-docs-heading">Download Documents</h2>
                <div className="search-box">
                    <input
                        type="text"
                        placeholder="Search for CSV file..."
                        value={searchText}
                        onChange={handleSearchTextChanged}
                    />
                </div>
                <button className="search-button" type="submit">
                    Search
                </button>
            <button className="download-button-card" onClick={handleDownloadButtonClick}>
                Download
            </button>
        </div>
    );
};

export default AdminDownload;
