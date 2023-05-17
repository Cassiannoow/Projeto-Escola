import React, { useEffect, useState } from 'react';
import './CrudAluno.css';
import Main from '../template/Main';
import UserService from '../../Services/UserService';
const title = "Cadastro de Alunos";
export default function CrudAluno(props) {
    const [lista, setLista] = useState([]);
    const [mens, setMens] = useState([]);
    useEffect(() => {
        UserService.getProfessorBoard().then(
            (response) => {
                console.log("useEffect getProfessorBoard: " + response.data)
                setLista(response.data);
                setMens(null);
            },
            (error) => {
                const _mens =
                    (error.response &&
                        error.response.data &&
                        error.response.data.message) ||
                    error.message ||
                    error.toString();
                setMens(_mens);
                console.log("_mens: " + _mens);
            }
        );
    }, []);

    const renderTable = () => {
        return (
            <div className="listagem">
                <table className="listaAlunos" id="tblListaAlunos">
                    <thead>
                        <tr className="cabecTabela">
                            <th className="tabTituloRa">Ra</th>
                            <th className="tabTituloNome">Nome</th>
                            <th className="tabTituloCurso">Curso</th>
                        </tr>
                    </thead>
                    <tbody>
                        {lista.map(
                            (aluno) =>
                                <tr key={aluno.id}><td>{aluno.ra}</td>
                                    <td>{aluno.nome}</td>
                                    <td>{aluno.codCurso}</td>
                                </tr>
                        )}
                    </tbody>
                </table>
            </div>
        )
    }
    return (
        <Main title={title}>
            {(mens) ? "Problema com conexão ou autorização (contactar administrador)." : renderTable()}
        </Main>
    )
}
