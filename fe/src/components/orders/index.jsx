import React, { useState, useEffect, useMemo, useCallback } from 'react';
import { Button, Dropdown, Menu, Table, Pagination } from 'antd';
import { Link } from 'react-router-dom'
import SalesFilter from './SalesFilter'
import { getSales } from '../../services/sales'

const columns = [
  {
    title: 'No Factura',
    dataIndex: 'id',
    key: 'id',
  },
  {
    title: 'Fecha',
    dataIndex: 'billDate',
    key: 'billDate',
  },
  {
    title: 'Proveedor',
    dataIndex: 'customerName',
    key: 'customerName',
  },
  {
    title: 'Dirección',
    dataIndex: 'customerAddress',
    key: 'customerAddress',
  },
  {
    title: 'Teléfono',
    dataIndex: 'customerPhone',
    key: 'customerPhone',
  },
  {
    title: 'Acciones',
    dataIndex: 'id',
    key: 'id',
  render: (id, item) => 
    <Link to={`/orders/detail/${id}`} key={id} type="default">Ver Detalle</Link>
  }
];

const Orders = () => {
  const [pageSize, setPageSize] = useState(10);
  const [currentPage, setCurrentPage] = useState(51);
  const[sales, setSales] = useState(() => []) ;
  const [initValues, setInitValues] = useState(false);
  const totalItems = useMemo(() => sales.length, [sales]);
  const items = useMemo(() => {
    return (sales.map(function(item){
      var clone = Object.assign({}, item); // Objects are pass by referenced, hence, you need to clone object
      clone.key = item.id;
      return clone;
    }));
  }, [sales]);


  const loadInitialValues = () => {
    getSales().then(res => {
      const { data } = res;
      setSales(data);
      setInitValues(true);
    });
  }

  useEffect(() => {
    if(!initValues) {
      loadInitialValues();
    }}, [sales]);

  const onShowSizeChange = (current, _pageSize) => {
    console.log(current, _pageSize);
    setPageSize(_pageSize);
  }

  const onPageChange = (page, _pageSize) => {
    console.log(page, pageSize);
    setCurrentPage(page);
  }

  const search = (filter) => {
    getSales(filter).then(res => {
      const { data } = res;
      setSales(data);
    });
  }

  return (
    <>
    <h3>Ventas grandes proveedores</h3>
    <SalesFilter search={search}/>
    <Table dataSource={items} columns={columns} />
    <Pagination
      showSizeChanger
      onShowSizeChange={onShowSizeChange}
      onChange={onPageChange}
      defaultCurrent={1}
      total={totalItems}
      defaultPageSize = {10}
      pageSize = {pageSize}
    />
    </>
  )
}

export default Orders;