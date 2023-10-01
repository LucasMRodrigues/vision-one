import React from 'react'
import { Link } from 'react-router-dom'

import '../../App.css'

export default function SignUpPage() {

    return (
        <div className="text-center m-5-auto">
            <h2>Vision One</h2>
            <h5>Crie sua conta</h5>
            <form action="/home">
                <p>
                    <label>Usuário</label><br/>
                    <input type="text" name="first_name" required />
                </p>
                <p>
                    <label>E-mail</label><br/>
                    <input type="email" name="email" required />
                </p>
                <p>
                    <label>Senha</label><br/>
                    <input type="password" name="password" requiredc />
                </p>
                <p>
                    <button id="sub_btn" type="submit">Registrar</button>
                </p>
            </form>
            <footer>
                <p><Link to="/">Página principal</Link>.</p>
            </footer>
        </div>
    )

}
