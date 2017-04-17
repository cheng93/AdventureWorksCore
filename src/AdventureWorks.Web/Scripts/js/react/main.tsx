import React from 'react';
import { render } from 'react-dom';
import { App } from './app/app.component';

import '../../css/site.css';

render(
  <App />,
  document.getElementById('app')
);