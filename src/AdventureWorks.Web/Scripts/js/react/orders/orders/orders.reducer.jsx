import { ORDERS_LOADING, ORDERS_RECEIVED } from './orders.actions'

export function ordersReducer(state = {
  isLoading: false,
  items: []
}, action) {
  switch (action.type) {
    case ORDERS_LOADING:
      return Object.assign({}, state, {
        isLoading: true
      });
    case ORDERS_RECEIVED:
      return Object.assign({}, state, {
        isLoading: false,
        items: action.orders
      });
    default:
      return state;
  }
}