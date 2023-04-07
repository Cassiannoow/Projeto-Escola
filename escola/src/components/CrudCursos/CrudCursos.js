import React, { Component } from 'react';
import axios from 'axios';
import './CrudCursos.css';
import Main from '../template/Main';

const title = "Cadastro de Cursos";

const urlAPI = "http://localhost:5041/api/curso";

const initialState = {
    curso: {id: 0, codCurso: 0, nomeCurso: '', periodo: ''},
    lista: []
}
export default class CrudCursos extends Component {

    state = {...initialState}

    componentDidMount(){
        axios(urlAPI).then(resp =>{
            this.setState({ lista: resp.data })
        })
    }

    renderTable() {
        return (
            <div className="listagem">
                <table className="listaCursos" id="tblListaCursos">
                    <thead>
                        <tr className="cabecTabela">
                            <th className="tabTituloCodCurso">Código</th>
                            <th className="tabTituloNomeCurso">Nome do Curso</th>
                            <th className="tabTituloPeriodoCurso">Periodo</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.lista.map(
                            (curso) =>
                            <tr key={curso.id}>
                                <td>{curso.codCurso}</td>
                                <td>{curso.nomeCurso}</td>
                                <td>{curso.periodo}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        )
    }
    render() {
        return (
            <Main title={title}>
                {this.renderTable()}
            </Main>
        )
    }   
}