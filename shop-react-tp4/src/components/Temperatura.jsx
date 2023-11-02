import React,{useState} from 'react'

const Temperatura = () => {
    const [temperatura, setTemperatura] = useState(19)
    const subir = () => (
        setTemperatura(temperatura + 1)
    )
    const bajar = () => (
        setTemperatura(temperatura - 1)
    )
  return (
    <div>
        <h2>La temperatura es: {temperatura}</h2>
        <button onClick={subir}>Aumentar temperatura</button>
        <button onClick={bajar}>Reducir temperatura</button>
    </div>
  )
}

export default Temperatura