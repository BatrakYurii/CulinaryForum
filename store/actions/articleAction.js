import {GET_ARTICLES, GET_ARTICLE, UPDATE_ARTICLE, CREATE_ARTICLE, DELETE_ARTICLE, ARTICLES_ERROR, LOGIN_FAIL} from '../types'
import axios from 'axios'
import host from '../setting/hostSetting'
import {token} from '../setting/tokenSetting'

export const getArticles = (queryParams) => async dispatch => {
    
    try{
        const res = await axios.get(`${host}articles?${queryParams}`);
        dispatch( {
            type: GET_ARTICLES,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: ARTICLES_ERROR,
            payload: console.log(e),
        })
    }
}

export const getArticle = (id) => async dispatch => {
    
    try{
        const article = await axios.get(`https://localhost:44389/api/Articles/${id}`);
        //const user = await axios.get(`https://localhost:44389/api/users/${id}`);

        dispatch( {
            type: GET_ARTICLE,
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



export const createArticle = (article) => async (dispatch) => {
    try{
       
        debugger;
        await axios.post(`${host}Articles`, 
        {title: article.title,
             content: article.content, 
             cuisineNationality: article.cuisineNationality, 
             isVegan: article.isVegan,
             categories: ad.categories,
             cookingTime: {hours: article.cookingTime.hours, minutes: article.cookingTime.minutes}
            }, token);
        let res = await axios.get(`${host}Articles`);
        window.location.reload()
        dispatch({
            type: CREATE_ARTICLE,
            payload: res.data
        })
    }
    catch (e) {
        if (e.response.status === 401) {
            window.location.href = '/login'
            dispatch({
                type: UNAUTHORIZED,
                payload: console.log(e),
            })
            dispatch({
                type: ARTICLES_ERROR,
                payload: console.log(e),
            })
        }
    }
}

export const updateArticle = (id, article) => async (dispatch) => {
    try{
        debugger;
        await axios.put(`${host}Articles/edit/${id}`, article, token)

        dispatch({
            type: UPDATE_ARTICLE,
            payload: article
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

export const deleteArticle = (id) => async (dispatch) => {
    try{
        debugger;
        await axios.delete(`${host}articles/delete/${id}`, token)

        dispatch({
            type: DELETE_ARTICLE,
            payload: id
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