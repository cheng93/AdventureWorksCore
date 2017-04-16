import React, { Component } from 'react';

function TableBodyRow(props) {
  return (
    <tr>
      <td>{props.row.id}</td>
      <td>{props.row.title}</td>
      <td>{props.row.count}</td>
    </tr>
  )
}

export class TableBody extends Component {
  render() {
    const tableRows = this.props.rows
      .map(row =>
        <TableBodyRow key={row.id} row={row} />
      );

    return (
      <tbody>
        {tableRows}
      </tbody>
    );
  }
}