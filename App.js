import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import {Routes, Route, BrowserRouter as Router} from 'react-router-dom';
import Nav from './nav'
import Singup from './component/singup'
import Login from './component/login'
import {Home} from './component/home';


function App() {
  return (
    <Router>
      <div className="App"> 
      <Nav />     
        <Routes>
          <Route path ="/singin" element={<Login />} />
          <Route path ="/home" element={<Home />} /> 
          <Route path ="/singup" element={<Singup />} />
        </Routes>     
      </div>
    </Router>
  );
}

export default App;

