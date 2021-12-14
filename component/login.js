import React, { Component } from "react";
import { connect } from "react-redux";
import { login } from "../store/actions/loginAction";
import {Form, Button} from 'react-bootstrap'
import { ThemeConsumer } from "react-bootstrap/esm/ThemeProvider";

class Login extends Component {
  constructor(props) {
    super(props);
    this.onInputLogin = this.onInputLogin.bind(this);
    this.onChangeEmail = this.onChangeEmail.bind(this);
    this.onChangePassword = this.onChangePassword.bind(this);

    this.state = {
      email: "",
      password: "",
      loading: false,
    };
  }

  onChangeEmail(e) {
    this.setState({
      email: e.target.value,
    });
  }

  onChangePassword(e) {
    this.setState({
      password: e.target.value,
    });
  }

  onInputLogin() {

    this.props.login({email: this.state.email, password: this.state.password});
  }




  render() {
    return <Form>
    <Form.Group className="mb-3" controlId="formBasicEmail">
      <Form.Label>Email address</Form.Label>
      <Form.Control type="email" placeholder="Enter email" onChange={this.onChangeEmail}/>
      <Form.Text className="text-muted">
        We'll never share your email with anyone else.
      </Form.Text>
    </Form.Group>
  
    <Form.Group className="mb-3" controlId="formBasicPassword">
      <Form.Label>Password</Form.Label>
      <Form.Control type="password" placeholder="Password" onChange={this.onChangePassword}/>
    </Form.Group>
    <Form.Group className="mb-3" controlId="formBasicCheckbox">
      <Form.Check type="checkbox" label="Check me out" />
    </Form.Group>
    <Button variant="primary" type="submit" onClick={this.onInputLogin}>
      Submit
    </Button>
  </Form>  
  }
}
  

export default connect(null, {login} )(Login);
  