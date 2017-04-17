import { combineReducers } from 'redux';

import { ordersReducer } from '../orders/orders/orders.reducers';

export const appReducers = combineReducers({
  orders: ordersReducer
});