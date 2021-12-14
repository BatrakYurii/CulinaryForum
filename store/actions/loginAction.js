import {LOGIN, LOGIN_FAIL} from '../types'
import axios from 'axios'
import host from '../setting/hostSetting'

export const login = (credentials) => async dispatch => {
    try{
        debugger;
        const res = await axios.post(`https://localhost:44389/api/auth/login`, credentials)
        console.log(res);
        dispatch({
            type: LOGIN,
            payload: res.data
        })
        window.location.href = '/';
    }
    catch(e){

        dispatch({
            type: LOGIN_FAIL,
            payload: console.log(e),
        })
    }
}

