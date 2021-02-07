import React, { useState } from 'react';
import { Button, Layout, Space } from 'antd';
import './App.css';
import { BrowserRouter as Router, Switch, Route, Link, useRouteMatch} from 'react-router-dom'
import Login from './components/login';
import Signup from './components/login/Signup';
import Orders from './components/orders';
import OrdersDetail from './components/orders/Detail';

const { Header, Footer, Sider, Content } = Layout; 

const App = (props) => { 
  // const authUser = localStorage.getItem('tokenid');
  const [token, setToken] = useState();
  const [register, setRegister] = useState(false);
  
  if(!token) {
    if(!register){
      return (<Login setToken={setToken} setRegister={setRegister} />);
    } else {
      return (<Signup setToken={setToken} setRegister={setRegister} />);
    }
  }
  const logout = () => {
    localStorage.removeItem("tokenid");
    setToken(null);
  };
  return (
    <Router>
    <Layout >
      <Header>
      <Space size={100}>
      <Link to="/" className="gx-d-block gx-d-lg-none gx-pointer">
      <span>Inalambria</span></Link>
        
        <Button onClick={() => logout()}>Cerrar sesión</Button>
        </Space>
        </Header>
      <Layout>
      <Content style={{ margin: '24px 16px 0', overflow: 'initial' }}>
        
          <Switch>
            <Route exact path="/" component={Orders}/>
            <Route exact path="/orders" component={Orders}/>
            <Route exact path="/orders/detail/:orderId"  component={OrdersDetail}/>
          </Switch>
        </Content>
        </Layout>
      <Footer>Creado por: @lexmrco</Footer>
    </Layout>
    </Router>
  );
}

export default App;
