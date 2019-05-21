import React, { Component } from 'react';
import GroupTittle from './GroupTittle';
import GroupStudentsList from './GroupStudentsList';
import AddingStudentToGroupModal from './AddingStudentToGroupModal';
import Axios from 'axios';

export class GroupPage extends Component {
    static displayName = GroupPage.name;

    constructor(props) {
        super(props);
        this.state = {
            group: {},
            groupStudents: [],
            addingStudentToGroupModalVisible: false
        }
        this.AddingStudenToGroupModalHandler = this.AddingStudenToGroupModalHandler.bind(AddingStudentToGroupModal);
    }

    componentDidMount() {
        this.populateCurrentGroupData();
        this.populateCurrentGroupStudentsData();
    }

    AddingStudenToGroupModalHandler = event => {
        if (this.state.addingStudentToGroupModalVisible === false) {
            this.setState({ addingStudentToGroupModalVisible: true });
        }
        else {
            this.setState({ addingStudentToGroupModalVisible: false });
        }
    }

    render() {
        return (
            <div>
                <h1>Current Group Info</h1>
                <GroupTittle group={this.state.group} />
                <br />
                <button className="primary"
                    onClick={this.AddingStudenToGroupModalHandler}>Додати студента до групи</button>
                <GroupStudentsList groupStudents={this.state.groupStudents} />
                <AddingStudentToGroupModal visible={this.state.addingStudentToGroupModalVisible}
                    close={this.AddingStudenToGroupModalHandler} />
            </div>
        );
    }

    async populateCurrentGroupData() {
        const id = this.props.match.params.id;
        const responce = await Axios.get(`api/groups/${id}`);
        const data = await responce.data;
        this.setState({ group: data });
    }

    async populateCurrentGroupStudentsData() {
        const id = this.props.match.params.id;
        const responce = await Axios.get(`api/groups/${id}/users/`);
        const data = await responce.data;
        console.log(data);
        this.setState({ groupStudents: data });
    }
}