import React, { Component } from 'react';

function TableHeaderCell(props) {
  return <th>{props.name}</th>
}

export function TableHead({ columns }) {
  let c = columns
    .map((column) =>
      <TableHeaderCell key={column.key} name={column.name} />
    );
  return (
    <thead>
      <tr>
        {c}
      </tr>
    </thead>
  );
}
