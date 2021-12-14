import React, {Component} from 'react';
import {connect} from 'react-redux';
import {register} from '../store/actions/registerAction';

class Signup extends Component {
  state = {
    username: "",
    password: "",
    email: ""
   
  }

  handleChange = event => {
    this.setState({
      [event.target.name]: event.target.value
    });
  }

  handleSubmit = event => {
    event.preventDefault()
    this.props.userPostFetch(this.state)
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <h1>Sign Up For An Account</h1>

        <label>Username</label>
        <input
          name='username'
          placeholder='Username'
          value={this.state.username}
          onChange={this.handleChange}
          /><br/>

        <label>Password</label>
        <input
          type='password'
          name='password'
          placeholder='Password'
          value={this.state.password}
          onChange={this.handleChange}
          /><br/>

        <label>Email</label>
          <input
            name='email'
            placeholder='email'
            value={this.state.email}
            onChange={this.handleChange}
            /><br/>
        <input type='submit'/>
      </form>
    )
  }
}



export default connect(null, register)(Signup)