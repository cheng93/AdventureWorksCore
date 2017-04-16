import React, { Component } from 'react';

function TableHeaderCell(props) {
  return <th>{props.name}</th>
}

export class TableHead extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    const columns = this.props.columns
      .map((column) =>
        <TableHeaderCell key={column.key} name={column.name} />
      );
    return (
      <thead>
        <tr>
          {columns}
        </tr>
      </thead>
    );
  }
}