import React from 'react';
import './App.css';
import Contador from './components/Contador'
import Listado from './components/Listado'; 
function App() {
  return (
    <div className="App">
      <h1>Shop Web - Decorator</h1>
      <Contador></Contador>
      <Listado></Listado>
    </div>
  );
}

export default App;
