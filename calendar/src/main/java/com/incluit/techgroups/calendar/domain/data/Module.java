package com.incluit.techgroups.calendar.domain.data;

public record Module(Integer id, Integer Duration, Course course, Subject subject) {

    public static record Course(Integer id, String section, Academy academy) {

    }

    public static record Academy(Integer id, String name, String description) {

    }

    public static record Subject(Integer id, String name, Teacher teacher) {

    }

    public static record Teacher(Integer id, String name) {

    }
}
