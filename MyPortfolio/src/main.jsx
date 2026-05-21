import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'

window.addEventListener('DOMContentLoaded', () => {
  const rootEl = document.getElementById('root');
  if (!rootEl) {
    console.error("React root element not found!");
    return;
  }

  ReactDOM.createRoot(rootEl).render(
    <React.StrictMode>
      <App />
    </React.StrictMode>
  );
});
