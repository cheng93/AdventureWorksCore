import React from 'react';
import { render } from 'react-dom';
import { createStore, applyMiddleware  } from 'redux';
import thunkMiddleware from 'redux-thunk';

import { appReducers } from './app/app.reducers';
import { App } from './app/app.component';

import '../../css/site.css';

let store = createStore(
  appReducers,
  applyMiddleware(
    thunkMiddleware
));

render(
  <App store={store} />,
  document.getElementById('app')
);