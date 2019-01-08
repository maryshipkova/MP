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
        };
        this.addState = this.addState.bind(this);
        //this.nothingChanged = this.nothingChanged.bind(this);
    }

    componentDidMount() {
        console.log(this.props.patientid);
        fetch(`${serverDomain}/patients/${this.props.patientid}/history`).then(res => {
            return res.json();
        }).then(res => {
            this.setState({statuses: res.data.history.statuses.list});
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

    componentWillReceiveProps(nextProps){
        fetch(`${serverDomain}/patients/${nextProps.patientid}/history`).then(res => {
            return res.json();
        }).then(res => {
            this.setState({statuses: res.data.history.statuses.list});
        });
    }

    getMaxStatusId(){
       let state = this.state.statuses.slice();
       state = state.sort((a,b)=>{
           return a.statusId < b.statusId
       });
       return state[0].statusId;
    }

    addState() {
        let currentState = this.state.statuses.slice();
        this.getMaxStatusId();
        currentState.push({
            statusId: this.getMaxStatusId()+1,
            parameters:{},
            medicines:[]
        });
        this.setState({
            statuses: currentState,
        });
    }

    componentDidUpdate() {
        //this.button.scrollIntoView({behavior: "smooth"});
    }

    /*nothingChanged(listItemId) {
        let statuses = this.state.statuses.slice();
        for (let stateIndex in statuses) {
            if (states[stateIndex].leftSide.id === listItemId) {
                states[stateIndex] = states[stateIndex - 1];
                this.setState({
                    states
                });
                break;
            }
        }
    }*/

    render() {
        return (
            <section className="timeline">
                <ul ref={(ul) => this.list = ul}>
                    {this.state.statuses.map(status => {
                        return <PatientTimeLineItem
                            {...status}
                            patientid={this.props.patientid}
                            key={status.statusId}/>
                    })}
                    <li>
                        <button className="add-btn"
                                onClick={this.addState}
                                ref={button => this.button = button}
                        >
                            add state
                        </button>
                    </li>
                </ul>
            </section>
        );
    }
}
