import axios from "axios";
const API_URL = "http://localhost:5041/api/";
// Cadastro Aluno: role professor
// Cadastro Curso: role professor
// Carômetro: todos
const user = JSON.parse(localStorage.getItem('user'));

const getPublicContent = () => {
    return axios.get(API_URL + "carometro");
};

const getProfessorBoard = async () => {
    return await axios.get(API_URL + "aluno/GetAll", {
        headers: {
            Authorization:
                'Bearer ' + user.token
        }
    });
};

const UserService = {
    getPublicContent,
    getProfessorBoard
};
export default UserService;