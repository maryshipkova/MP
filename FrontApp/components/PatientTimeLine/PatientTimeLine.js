// @flow

import React from "react";
import "./style.css";
import {PatientTimeLineItem} from "../PatientTimeLineItem";


export class PatientTimeLine extends React.Component {
    constructor() {
        super();
        this.state = {
            states: [
                {
                    leftSide: {
                        id: 1,
                        pef: 0.2,
                        opf2: 0.3,
                        isHospitalized: true,
                        isWheezing: true,
                        readOnly: true,
                    },
                    rightSide: "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium At\n" +
                    "                vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium"
                },
                {
                    leftSide: {
                        id: 2,
                        pef: 0.25,
                        opf2: 0.38,
                        isHospitalized: false,
                        isWheezing: true,
                        readOnly: true,
                    },
                    rightSide: "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium At\n" +
                    "                vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium"
                },
                {
                    leftSide: {
                        id: 3,
                        pef: 0.45,
                        opf2: 0.88,
                        isHospitalized: false,
                        isWheezing: true,
                        readOnly: true,
                    },
                    rightSide: "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium At\n" +
                    "                vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium"
                },

            ],
        };
        this.addState = this.addState.bind(this);
        this.nothingChanged = this.nothingChanged.bind(this);
    }

    componentDidMount() {
        let items = this.list.childNodes;

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
        window.addEventListener("scroll", showListItem);
    }

    addState() {
        let currentState = this.state.states.slice();
        currentState.push({
            leftSide: {
                readOnly: false,
            },
            rightSide: "World"
        });
        this.setState({
            states: currentState,
        });
    }

    componentDidUpdate() {
        this.button.scrollIntoView({behavior: "smooth"});
    }

    nothingChanged(listItemId) {
        let states = this.state.states.slice();
        for (let stateIndex in states) {
            if (states[stateIndex].leftSide.id === listItemId) {
                states[stateIndex] = states[stateIndex - 1];
                this.setState({
                    states
                });
                break;
            }
        }
    }

    render() {
        return (
            <section className="timeline">
                <ul ref={(ul) => this.list = ul}>
                    {this.state.states.map(state => {
                        return <PatientTimeLineItem
                            {...state}
                            key={state.id} />
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
