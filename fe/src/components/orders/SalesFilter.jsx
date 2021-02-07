import React, { useState } from 'react';
import { Form, Input, Button, Row, Col } from 'antd';

const SalesFilter = ( { search } ) => {
  const [form] = Form.useForm();
  const [salesFilter, setSalesFilter] = useState({
    since: '',
    until: '',
    orderId: '',
    custName: ''
  })

  const { since, until, orderId, custName } = salesFilter;

  const onChangeHandle = e => {
    setSalesFilter({
      ...salesFilter,
      [e.target.name] : e.target.value
    });
  }

  const onFinish = e => {
    search({...salesFilter});
  };

  return (
    <>
    <Form
      className="ant-advanced-search-form"
      name="form_filter"
      form={form}
      onFinish={onFinish}
    >
      <Row gutter={24}>
        <Col span={8}>
          <Form.Item label="Fecha factura:" style={{ marginBottom: 0 }}>
            <Form.Item
              name="since"
              value={since}
              onChange={onChangeHandle}
              style={{ marginBottom: 0 }}
              style={{ display: 'inline-block', width: 'calc(50% - 8px)' }}
            >
              <Input name="since" id="since" placeholder="Desde" />
            </Form.Item>
            <Form.Item
                name="until"
                value={until}
                style={{ display: 'inline-block', width: 'calc(50% - 8px)' }}
                onChange={onChangeHandle}
            >
                <Input 
                  name="until"
                  id="until"
                  placeholder="Hasta" 
                />
            </Form.Item>
          </Form.Item>
        </Col>
        <Col span={8}>
          <Form.Item
              name="orderId"
              label="Número factura:"
              value={orderId}
              onChange={onChangeHandle}
          >
              <Input 
                name="orderId"
                id="orderId"
                placeholder="Número factura" 
              />
          </Form.Item>
        </Col>
        <Col span={8}>
          <Form.Item
            name="custName"
            label="Proveedor:"
            value={custName}
            onChange={onChangeHandle}
          >
            <Input 
              name="custName"
              id="custName"
              placeholder="Proveedor" 
            />
          </Form.Item>
        </Col>
        <Col span={6}>

        </Col>
      </Row>
      <Row>
        <Col
          span={24}
          style={{
            textAlign: 'right',
          }}
        >
          <Button type="primary" htmlType="submit">
            Buscar
          </Button>
          <Button
            style={{
              margin: '0 8px',
            }}
            onClick={() => {
              form.resetFields();
            }}
          >
            Limpiar
          </Button>
        </Col>
      </Row>  
      </Form>
    </>
  )
}

export default SalesFilter;