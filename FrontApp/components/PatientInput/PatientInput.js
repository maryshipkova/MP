// @flow

import React from 'react';
import './style.css';
import {PatientModel} from 'models/PatientModel';
import {sexType} from 'types/SexType';
import {serverDomain} from "constants/server";

type Props = {};

type State = {
    patient: PatientModel
};

export class PatientInput extends React.Component<Props, State> {

    constructor(props) {
        super(props);
        this.state = {
            patient: {
                firstName: "",
                lastName: "",
                genderType: 0,
                birthDate: ""
            }
        };
        this.addPatient.bind(this);
    }


    addPatient(event) {
        this.firstName = this.firstName.value;
        this.lastName = this.lastName.value;
        this.genderType = this.genderType[this.genderType.selectedIndex].value;
        this.birthDate = this.birthDate.value;

        const requestOptions = {
            headers: new Headers({'content-type': 'application/json'}),
            method: "POST",
            mode: 'cors',
            cache: 'default',
            body: JSON.stringify({
                FirstName: this.firstName,
                LastName: this.lastName,
                GenderType: this.genderType,
                BirthDate: this.birthDate
            })
        };
        fetch(`${serverDomain}/patients`, requestOptions);

        event.preventDefault();
        window.location.reload();
    }

    render() {
        return (
            <div className="patientInput">
                <button className="btn btn-primary" data-toggle="modal" data-target="#addPatient">Добавить Пацента</button>

                <div className="modal" id="addPatient" tabIndex="-1" role="dialog">
                    <div className="modal-dialog" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title" id="exampleModalLabel">Новый пациент</h5>
                                <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <div className="modal-body">
                                <form className="patient" onSubmit={e => this.addPatient(e)}>
                                    <div className="form-group">
                                        <label>Имя</label>
                                        <input className="form-control" ref={input => this.firstName = input} placeholder="Имя"/>
                                    </div>

                                    <div className="form-group">
                                        <label>Фамилия</label>
                                        <input className="form-control" ref={input => this.lastName = input} placeholder="Фамилия"/>
                                    </div>


                                    <div className="form-group">
                                        <label>Пол</label>
                                        <select className="form-control" ref={selected => this.genderType = selected} defaultValue="0">
                                            <option value="1">Мужской</option>
                                            <option value="2">Женский</option>
                                            <option value="0">Не указано</option>
                                        </select>
                                    </div>


                                    <div className="form-group">
                                        <label>Дата рождения</label>
                                        <input className="form-control" type="date" ref={date => this.birthDate = date}/>
                                    </div>

                                    <button type="submit" className="btn btn-primary">Готово</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
};