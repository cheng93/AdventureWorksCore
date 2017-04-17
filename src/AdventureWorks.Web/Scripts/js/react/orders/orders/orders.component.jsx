import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Table } from '../../table/table.component';
import { fetchOrders } from './orders.actions';

const columns = [
  { key: 'orderId', name: 'ID' },
  { key: 'customerId', name: 'Customer' },
  { key: 'orderDate', name: 'Order Date' }
];

function mapStateToProps(state) {
  return {
    rows: state.orders.items,
    columns: columns
  };
}

function mapDispatchToProps(dispatch) {
  return {
    onLoad: () => dispatch(fetchOrders())
  }
}

export const Orders = connect(
  mapStateToProps,
  mapDispatchToProps
)(Table);