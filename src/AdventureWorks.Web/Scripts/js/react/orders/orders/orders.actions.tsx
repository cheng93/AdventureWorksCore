import axios from 'axios';

import { Order } from '../orders.models';

export const ORDERS_LOADING = 'ORDERS_LOADING';
export const ORDERS_RECEIVED = 'ORDERS_RECEIVED';

export function loadingOrders() {
  return {
    type: ORDERS_LOADING
  };
}

export function receivedOrders(orders) {
  return {
    type: ORDERS_RECEIVED,
    orders
  }
}

export function fetchOrders() {
  const endpoint = 'api/orders';

  return (dispatch) => {
    dispatch(loadingOrders());
    return axios.get(endpoint)
      .then(response => response.data as Order[])
      .then(json => dispatch(receivedOrders(json)));
  };
}