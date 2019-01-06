// @flow
"use strict";

import React from 'react';
import ReactDom from 'react-dom';
import {PatientList} from 'components/PatientList';
import {PatientInput} from 'components/PatientInput';
import {PatientTimeLine} from "./components/PatientTimeLine";

class Check extends React.Component {
    render() {
        return <React.Fragment>
            <PatientList/>
            <PatientInput/>
            <PatientTimeLine/>
        </React.Fragment>;
    }
}

ReactDom.render(
    <Check/>, document.getElementById('app')
);