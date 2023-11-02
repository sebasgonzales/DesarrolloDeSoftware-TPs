import React,{Fragment, useState} from 'react'

const Listado = () =>{
    const [numeros] = useState([1,2,3,4,5,6])
    return (
        <Fragment>
            <p>Item - index</p>
            <ul>
                {
                    numeros.map((item, index) => 
                        <li key={index}>
                            {item} - {index}
                        </li>
                    )
                }
            </ul>
        </Fragment>
    )
}

export default Listado
