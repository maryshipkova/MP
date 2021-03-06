// @flow

import React from 'react';
import './style.css';
import {PatientModel} from 'models/PatientModel';
import {sexType} from 'types/SexType';

export const Patient = (props: PatientModel) => {

    function getFullDate(date) {
        let newDate = new Date(date);
        return `${newDate.getDate()}.${newDate.getMonth() + 1}.${newDate.getFullYear()}`
    }

    function setPatientId(){
        props.setpatientid(props.patientId);
    }

    return (

        <li className={props.activePatient == props.patientId ? "active patient" : "patient"} onClick={setPatientId}>
            <p className="nameAgeGender">
                {`${props.lastName} ${props.firstName} ${props.genderType.name}, ${getFullDate(props.birthDate)}`}
            </p>
        </li>
    )
};
