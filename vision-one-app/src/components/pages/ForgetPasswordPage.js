import React from 'react'
import { Link } from 'react-router-dom'

import '../../App.css'

export default function ForgetPasswordPage() {
    return (
        <div className="text-center m-5-auto">
            <h2>Resetar sua senha</h2>
            <h5>Informe o e-mail cadastrado para receber sua nova senha</h5>
            <form action="/login">
                <p>
                    <label id="reset_pass_lbl">E-mail</label><br/>
                    <input type="email" name="email" required />
                </p>
                <p>
                    <button id="sub_btn" type="submit">Resetar senha</button>
                </p>
            </form>
            <footer>
                <p>Primeira vez? <Link to="/register">Crie uma conta</Link>.</p>
                <p><Link to="/">Página principal</Link>.</p>
            </footer>
        </div>
    )
}
