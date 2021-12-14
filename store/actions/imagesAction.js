import {} from '../types'
import axios from 'axios'
import host from '../setting/hostSetting'
import {token} from '../setting/tokenSetting'
import { Add_ARTICLE_IMAGES, ADD_AVATAR } from '../types'

export const getAvatar = (image) => async dispatch => {
    
    try{
        const res = await axios.get(`${host}UserAvatar`, image, token);
        dispatch( {
            type: GET_ARTICLES,
            payload: res.data
        })
    }
    catch (e) {
        if (e.response.status === 401) {
            window.location.href = '/login'
            dispatch({
                type: LOGIN_FAIL,
                payload: console.log(e),
            })
            dispatch({
                type: ARTICLES_ERROR,
                payload: console.log(e),
            })
        }
    }
}

export const addAvatar = (id) => async dispatch => {
    
    try{
        const article = await axios.get(`https://localhost:44389/api/Articles/${id}`);
        //const user = await axios.get(`https://localhost:44389/api/users/${id}`);

        dispatch( {
            type: ADD_AVATAR,
            payload: {article: article.data, user: user.data}
        })
    }
    catch(e){
        dispatch( {
            type: ARTICLES_ERROR,
            payload: console.log(e),
        })
    }
}

export const addAvatar = (id) => async dispatch => {
    
    try{
        const article = await axios.get(`https://localhost:44389/api/Articles/${id}`);
        //const user = await axios.get(`https://localhost:44389/api/users/${id}`);

        dispatch( {
            type: ADD_AVATAR,
            payload: {article: article.data, user: user.data}
        })
    }
    catch(e){
        dispatch( {
            type: ARTICLES_ERROR,
            payload: console.log(e),
        })
    }
}
