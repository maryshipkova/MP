// @flow
"use strict";

import React from 'react';
import ReactDom from 'react-dom';
import {PatientList} from 'components/PatientList'
import axios from 'axios'

class Check extends React.Component {

    render() {
        //Check HelloWorld
        axios.get('/api/Ontology/HelloWorld')
        .then(response => {
            console.log(response.data.message);
        })

        return <div>
            <PatientList/>
        </div>;
    }
}

ReactDom.render(
    <Check/>, document.getElementById('app')
);