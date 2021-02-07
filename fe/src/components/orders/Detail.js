import React, { useState, useEffect, useMemo } from 'react';
import { Button, Card, Row, Col, Table, Statistic } from 'antd';
import { getOrder } from '../../services/sales'
import { Link} from 'react-router-dom'

const detailColumns = [
  {
    title: 'Producto',
    dataIndex: 'productName',
    key: 'productName',
  },
  {
    title: 'Valor unitario',
    dataIndex: 'unitPrice',
    key: 'unitPrice',
  },
  {
    title: 'Cantidad',
    dataIndex: 'quantity',
    key: 'quantity',
  },
  {
    title: 'Total',
    dataIndex: 'id',
    key: 'id',
  render: (id, item) => 
    <span>${item.quantity * item.unitPrice}</span>
  },];

const OrderDetail = (props) => {
  const orderId = props.match.params.orderId;
  const[order, setOrder] = useState({
    id: '',
    billDate: '',
    billNumber: '',
    customerName: '',
    customerAddress: '',
    customerPhone: '',
    orderDetails: []
  });
  const [initValues, setInitValues] = useState(false);

  const {id, billDate, billNumber, customerName, customerAddress, customerPhone, orderDetails} = order;
  const items = useMemo(() => {
    return (orderDetails.map(function(item){
      var clone = Object.assign({}, item); // Objects are pass by referenced, hence, you need to clone object
      clone.key = item.productName;
      return clone;
    }));
  }, [order]);
  const total = useMemo(() => { 
    let sum = 0;
    orderDetails.forEach(function(item){
      sum += (item.quantity * item.unitPrice);
    });
    return sum;}, [order]);
  
  const loadInitialValues = () => {
    getOrder(orderId).then(res => {
      const { data } = res;
      setOrder(data);
      setInitValues(true);
    });
  }

  useEffect(() => {
    if(!initValues) {
      loadInitialValues();
    }}, [order]);

  return( 
    <Card title="Detalle venta">
      <Card>
        <Row>
            <Col span={8}><Statistic groupSeparator="" title="No. Factura:" value={billNumber} /></Col>
            <Col span={8}><Statistic title="Fecha:" value={billDate} format="yyyy-MM-dd"/></Col>
            <Col span={8}><Statistic title="Proveedor:" value={customerName}/></Col>
        </Row>
        <Row>
            <Col span={8}><Statistic title="Dirección:" value={customerAddress}/></Col>
            <Col span={8}><Statistic title="Teléfono:" value={customerPhone}/></Col>
            <Col span={8}><Statistic decimalSeparator="," groupSeparator="." title="Total Factura:" value={total} prefix="$"/></Col>
        </Row>
        <h3></h3>
        <Table dataSource={items} columns={detailColumns} />
      </Card>
      <Link to="/orders">Volver</Link>
  </Card>
  );

}
export default OrderDetail;