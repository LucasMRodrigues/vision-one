import React from 'react'
import { Link } from 'react-router-dom'

import '../../App.css'

export default function SignInPage() {
    return (
        <div className="text-center m-5-auto">
            <h2>Vision One</h2>
            <form action="/home">
                <p>
                    <label>Usuário ou e-mail</label><br/>
                    <input type="text" name="first_name" required />
                </p>
                <p>
                    <label>Senha</label>
                    <br/>
                    <input type="password" name="password" required />
                    <br/>
                    <Link to="/forget-password"><label
                    >Esqueceu a senha?</label></Link>
                </p>
                <br/>
                <p>
                    <button id="sub_btn" type="submit">Entrar</button>
                </p>
            </form>
            <footer>
                <p>Primeria vez? <Link to="/register">Crie uma conta</Link>.</p>
                <p><Link to="/">Página principal</Link>.</p>
            </footer>
        </div>
    )
}
