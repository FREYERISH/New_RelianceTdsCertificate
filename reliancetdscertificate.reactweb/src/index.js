/* eslint-disable no-unused-vars */
import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { createRoot } from 'react-dom/client';

import App from './App';


//const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
  /*<BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>)*/
    <App />
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
