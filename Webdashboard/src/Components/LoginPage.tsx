import React from 'react';
import IUser from './Interfaces/IUser';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const api = "http://192.168.1.135:44344/users"


const LoginPage: React.FC = (() => {

  const [username, setUsername] = React.useState<string>("");
  const [password, setPassword] = React.useState<string>("");
  const [loggedInUser, setLoggedInUser] = React.useState<IUser | null>(null);

  const user: IUser = {
    username: username,
    password: password
  }
  const Navigate = useNavigate();



  const Login = () => {
    setLoggedInUser(user)

    Navigate("/admin")
    const api = "http://192.168.1.135:44344/users"
    axios.post(api)
      .then(response => {

        console.log(response.data);
        // Do something with the data
      })
      .catch(error => {
        console.error('Error:', error);
      });


  }

  return (
    <div className="hero min-h-screen bg-base-200">
      <div className="hero-content flex-col lg:flex-row-reverse">
        <div className="text-center lg:text-left">
          <h1 className="text-5xl font-bold">Login</h1>
          <p className="py-6">Please provide your username and password</p>
        </div>
        <div className="card flex-shrink-0 w-full max-w-sm shadow-2xl bg-base-100">
          <div className="card-body">
            <div className="form-control">
              <label className="label">
                <span className="label-text">Email</span>
              </label>
              <input type="text" placeholder="Email" className="input input-bordered" onChange={(e) => setUsername(e.target.value)} />
            </div>
            <div className="form-control">
              <label className="label">
                <span className="label-text">Password</span>
              </label>
              <input type="password" placeholder="Password" className="input input-bordered" onChange={(e) => setPassword(e.target.value)} />
              <label className="label">
                <a href="#" className="label-text-alt link link-hover">Forgot password?</a>
              </label>
            </div>
            <div className="form-control mt-6">
              <button className="btn btn-primary" onClick={Login}>Login</button>
            </div>
          </div>
        </div>
      </div>
    </div>


  )
})


export default LoginPage

