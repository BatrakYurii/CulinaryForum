import React, { Component } from 'react'
import 'bootstrap/dist/css/bootstrap.css';
import {connect} from 'react-redux'
import {getArticles, getArticle, createArticle} from '../store/actions/articleAction'
import Homearticles from './homearticles';


 class Articles extends React.Component {
    componentDidMount(){
        this.props.getArticles();
    }

    render() {
        const {articles} = this.props.articles
        console.log(articles)
        
        return (
            <div>
                {articles.map(a => 
                     <Homearticles article ={a} />
                )}
            </div>
        )
    }
}

const mapStateToProps  = (state) => ({articles:state.articles});

export default connect(mapStateToProps, {getArticles, getArticle, createArticle})(Articles);