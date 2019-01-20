// @flow

import React from "react";
import "./style.css";
import {PatientTimeLineItem} from "../PatientTimeLineItem";
import {serverDomain} from "constants/server";

export class PatientTimeLine extends React.Component {
    constructor() {
        super();
        this.state = {
            statuses: [],
            patient: {},
            gender: ""
        };
        this.addState = this.addState.bind(this);
    }

    componentDidMount() {
        fetch(`${serverDomain}/patients/${this.props.patientid}/history`).then(res => {
            return res.json();
        }).then(res => {
            console.log(res.data);
            this.setState({
                patient: res.data.history.patient,
                statuses: res.data.history.statuses.list.reverse(),
                gender: res.data.history.patient.genderType.name
            });

        });

        /*let items = this.list.childNodes;

        function isElementInViewport(el) {
            let rect = el.getBoundingClientRect();
            return (
                (rect.top >= 0 &&
                    rect.left >= 0 &&
                    rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
                    rect.right <= (window.innerWidth || document.documentElement.clientWidth))
            );
        }

        function showListItem() {
            for (let i = 0; i < items.length; i++) {
                if (isElementInViewport(items[i])) {
                    items[i].classList.add("in-view");
                }
            }
        }

        window.addEventListener("load", showListItem);
        window.addEventListener("resize", showListItem);
        window.addEventListener("scroll", showListItem);*/
    }

    engGenderToRus(gender) {
        switch (gender) {
            case "Male":
                return "Муж.";
            case "Female":
                return "Жен.";
            case "None":
                return "Не указан";
        }
    }

    getFullDate(birthDate) {
        let date = new Date(birthDate);
        return `${date.getDate()}.${date.getMonth() + 1}.${date.getFullYear()}`
    }

    componentWillReceiveProps(nextProps) {
        fetch(`${serverDomain}/patients/${nextProps.patientid}/history`).then(res => {
            return res.json();
        }).then(res => {
            this.setState({
                patient: res.data.history.patient,
                statuses: res.data.history.statuses.list.reverse(),
                gender: res.data.history.patient.genderType.name
            });
        });
    }

    getMaxStatusId() {
        let state = this.state.statuses.slice();
        state = state.sort((a, b) => {
            return a.statusId < b.statusId
        });
        return state[0].statusId;
    }

    addState() {
        let currentState = this.state.statuses.slice();
        this.getMaxStatusId();
        currentState.unshift({
            statusId: this.getMaxStatusId() + 1,
            parameters: {},
            medicines: [],
            unsaved: true
        });
        this.setState({
            statuses: currentState,
        });
    }

    render() {
        return (
            <div>
                <div className="text-center patient-info">
                    <span className="text-muted mx-2">
                        Пациент:
                    </span>{`${this.state.patient.firstName} ${this.state.patient.lastName}`}
                    <span
                        className="text-muted mx-2">
                        Пол:
                    </span>{this.engGenderToRus(this.state.gender)}
                    <span className="text-muted mx-2">
                        Дата рождения:
                    </span>{this.getFullDate(this.state.patient.birthDate)}
                </div>
                <section className="timeline mt-3">
                    <ul ref={(ul) => this.list = ul}>
                        <li>
                            <button className="add-btn btn btn-primary"
                                    onClick={this.addState}
                                    ref={button => this.button = button}
                            >
                                Добавить состояние
                            </button>
                        </li>
                        {this.state.statuses.map(status => {
                            return <PatientTimeLineItem
                                {...status}
                                patientid={this.props.patientid}
                                key={status.statusId}/>
                        })}
                    </ul>
                </section>
            </div>
        );
    }
}
