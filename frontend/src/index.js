import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import axiosInstance from "./api/axiosInstance";
import { BrowserRouter } from 'react-router-dom';

fetch('/config.json')
  .then((response ) => response.json())
  .then((data) => {
    const baseUrl = data.baseUrl;

    axiosInstance.defaults.baseURL = baseUrl;
  
    const root = ReactDOM.createRoot(document.getElementById('root'));
    root.render(
      <React.StrictMode>
        <BrowserRouter>
          <App />
        </BrowserRouter>      
      </React.StrictMode>
    );   
  });

