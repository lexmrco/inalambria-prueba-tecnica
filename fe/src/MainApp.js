import { Button, Layout, Space } from 'antd';
import React from 'react';
// import './App.css';
import { BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import Orders from './components/orders';
import OrdersDetail from './components/orders/Detail';

const { Header, Footer, Sider, Content } = Layout; 

const MainApp = (props) => {
  const logout = () => {
    console.log("Cerrar sesion");
    localStorage.removeItem("tokenid");
    const { history } = props; 
    setTimeout(() => history.push('/signin'),3000);
  };
  return (
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
        <Router>
          <Switch>
            <Route exact path="/" component={Orders}/>
            <Route exact path="/orders" component={Orders}/>
            <Route exact path="/orders/detail/:orderId"  component={OrdersDetail}/>
          </Switch>
        </Router>
        </Content>
        </Layout>
      <Footer>Creado por: @lexmrco</Footer>
    </Layout>
  );
}

export default MainApp;
