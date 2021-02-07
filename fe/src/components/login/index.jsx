import React,{ Fragment, useState} from 'react';
import { Alert, Form, Input, Button, Checkbox } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import AxiosClient from '../../config/axios'
import PropTypes from 'prop-types';

const Login = ({ setToken, setRegister }) => {

    const [account, setAccount] = useState({ 
        userName: '', 
        password: ''
    })
    const { userName, password } = account;

    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);

    const onChangeHandle = e => {
        setAccount({
            ...account,
            [e.target.name] : e.target.value
        });
    }

    const onRegisterHandle = () => {
        console.log('registrar');
        setRegister(true);
    }

    const login = async () => { 
        setLoading(true);
        try {
            const response = await AxiosClient.post('auth', account);
            const { data } = response;
            if(data){
                localStorage.setItem('tokenid', data);
                setToken(data);
            } else {
                setError('Error en el servidor, no se puede iniciar sesión en este momento');
            }
            setLoading(false);
        } catch (error) {
            if(error.response && error.response.data)
                setError(error.response.data.message);
            else
                setError('Error en el servidor, no se puede iniciar sesión en este momento');
            setLoading(false);
        }
    };

    const onFinish = e => {
        login();
    };

    const onFinishFailed = e => {
        console.log('Error en el login');
    };

    return (
    <Fragment>
        <div className="wrapper">
            <div className="form-wrapper">      
                <h1>INICIAR SESIÓN</h1>
                <Form
                    name="form_login"
                    className="login-form"
                    initialValues={{
                        remember: true,
                    }}
                    onFinish={onFinish}
                    onFinishFailed={onFinishFailed}
                >
                <Form.Item
                    name="userName"
                    value={userName}
                    onChange={onChangeHandle}
                    rules={[
                    {
                        required: true,
                        message: 'Ingrese su nombre de usuario!',
                    },
                    ]}
                >
                    <Input name="userName" prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Usuario" />
                </Form.Item>
                <Form.Item
                    name="password"
                    value={password}
                    onChange={onChangeHandle}
                    rules={[
                    {
                        required: true,
                        message: 'Ingrese una contraseña!',
                    },
                    ]}
                >
                    <Input.Password 
                        name="password"
                        prefix={<LockOutlined className="site-form-item-icon" />}
                        placeholder="Contraseña"
                    />
                </Form.Item>
                <Form.Item>
                    <Button loading={loading} type="primary" htmlType="submit" className="login-form-button" block>
                        Iniciar sesión
                    </Button>
                    <a onClick={() => onRegisterHandle()}> Registrarse!</a>
                </Form.Item>
                </Form>
                {
                    error?
                    <Alert message={error} type="error" />:''
                }
                <i>Usuario: admin</i>
                <i>Contraseña: admin2021</i>
            </div>
        </div>        
    </Fragment>
  );
};
export default Login;

Login.propTypes = {
    setToken: PropTypes.func.isRequired,
    setRegister: PropTypes.func.isRequired
  }