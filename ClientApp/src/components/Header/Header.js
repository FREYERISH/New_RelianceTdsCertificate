import React from 'react';
import { Link } from 'react-router-dom';
import './Header.scss';
import PersonRoundedIcon from '@mui/icons-material/PersonRounded';
import reliance from '../../assets/reliance.png';

const Header = () => {
    const handleLogoClick = () => {
        // Redirect to home page
        window.location.href = '/';
    };
    const [isLogoVisible, setIsLogoVisible] = React.useState(false);

    React.useEffect(() => {
        setTimeout(() => {
            setIsLogoVisible(true);
        }, 100);
    }, []);

    return (
        <header className="header">
            <img
                src={reliance}
                alt="Company Logo"
                className={`header-logo ${isLogoVisible ? '' : 'hidden'}` 
                } onClick={handleLogoClick}
            />
            <nav >
                <Link to="/User">User</Link>
                <Link to="/Admin">Admin</Link>
            </nav>
            
            <div className="header-user">
                <PersonRoundedIcon />
                <span className="header-user-info">John Doe</span>
            </div>

            
        </header>
    );
};

export default Header;
