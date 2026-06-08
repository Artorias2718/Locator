import type { ReactElement } from "react";
import useGetPerson from "../../api/queryHooks/person/useGetPerson.ts";

const Profile = (): ReactElement => {
    // TODO: REMOVE THIS LATER!!! This should be handled by some authentication process
    const identifier = '';
    const { data, status } = useGetPerson(identifier);
    console.log(data);
    return (
        <>
            <h2>My Profile</h2>
        </>
    );
};

export default Profile;