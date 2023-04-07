import React from 'react';
import { Routes, Route } from "react-router-dom";
import Main from './components/template/Main';
import CrudAluno from './components/CrudAluno/CrudAluno';
import CrudCursos from './components/CrudCursos/CrudCursos';

export default function Rotas() {
    return (
        <Routes>
            <Route exact path='/'
                element={
                    <Main title="Bem Vindo!">
                        <div>Cadastro de alunos, cursos e carômetro</div>
                    </Main>
                }/>
            <Route path='/cursos' element={<CrudCursos />} />
            <Route exact path='/carometro'
            element={
                <Main title="Bem Vindo a aba de Carometro!">
                    <div>Area de carometo, ainda sendo desenvolvida</div>
                </Main>
            }/>
            <Route path='/alunos' element={<CrudAluno />} />
            <Route path='*' element={
                <Main title="Bem Vindo!">
                    <div>Página não encontrada</div>
                </Main>
            } />
        </Routes>
    )
}