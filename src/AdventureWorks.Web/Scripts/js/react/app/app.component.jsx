import React, { Component } from 'react';

import { AppRouter } from './app.router';


export class App extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return <AppRouter />
  }
}