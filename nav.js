import React from 'react';
import './App.css';
import {Link} from 'react-router-dom';

export class Nav extends React.Component{
    render(){
        return <nav>
            <ul className="nav-links">
                <Link to="/home">
                    <li>Home</li>
                </Link>
                <Link to="/singin">
                    <li>SingIn</li>
                </Link>
                <Link to="/singup">
                    <li>SingUp</li>
                </Link>
            </ul>
        </nav>
    }
}

export default Nav;