export enum Role {
    User = 'User',
    Admin = 'Admin'
}


export class User {
    id: number;
    username: string;
    password: string;
    firstName: string;
    lastName: string;
    role: Role;
    token?: string;
}