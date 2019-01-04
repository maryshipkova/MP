// @flow
"use strict";

import React from 'react';
import ReactDom from 'react-dom';
import {PatientList} from 'components/PatientList';
import {PatientInput} from 'components/PatientInput';

class Check extends React.Component {
    render() {
        return <React.Fragment>
            <PatientList/>
            <PatientInput/>
        </React.Fragment>;
    }
}

ReactDom.render(
    <Check/>, document.getElementById('app')
);