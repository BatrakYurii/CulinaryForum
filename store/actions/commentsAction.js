import {GET_COMMENTS, UPDATE_COMMENT, CREATE_COMMENT, DELETE_COMMENT, COMMENTS_ERROR, LOGIN_FAIL} from '../types'
import axios from 'axios'
import host from '../setting/hostSetting'
import { token } from '../setting/tokenSetting'

export const getComments = (articleId) => async dispatch => {
    
    try{
        const res = await axios.get(`${host}comments/ForArticles/${articleId}`, token)
        dispatch( {
            type: GET_COMMENTS,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: COMMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const createComment = (comment) => async (dispatch) => {
    try{
       
        debugger;
        await axios.post(`${host}/Articles`, 
        {content: comment.content,
             articleId: comment.articleId}, token);

        await axios.post(`${host}comments/new`);
        let articleId = comment.articleId;
        let res = axios.get(`${host}comments/ForArticle/${articleId}`);
        window.location.reload()
        dispatch({
            type: CREATE_COMMENT,
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

export const deleteComments = (id) => async (dispatch) => {
    try{
        debugger;
        await axios.delete(`${host}comments/${id}`, token)

        dispatch({
            type: DELETE_USER,
            payload: id
        })
    }
    catch(e){
        dispatch({
            type: USERS_ERROR,
            payload: console.log(e),
        })
    }
}